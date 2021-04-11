﻿using System;
using System.Collections.Generic;
using DirtyMesh;
using UnityEngine;

namespace Managers
{
    public class StarHandler : MonoBehaviour
    {
        public GameObject[] stars;
        public GameObject[] noStars;

        private int remainingSoapCount;
        private int totalSoapAmount;

        private float _percentage;

        private CountManager _countManager;
        private DirtyMeshManager _meshManager;

        private GameObject leftNoStar;
        private GameObject midNoStar;
        private GameObject rightNoStar;

        private GameObject leftStar;
        private GameObject midStar;
        private GameObject rightStar;

        public GameObject starMenu;

        public bool menuIsOpen;

        private void Start()
        {
            _countManager = GameObject.FindObjectOfType<CountManager>();
            _meshManager = GameObject.FindGameObjectWithTag("meshManager").GetComponent<DirtyMeshManager>();
            stars = new GameObject[3];
            noStars = new GameObject[3];
        }

        private void Update()
        {
            if (_meshManager.levelFinished)
            {
                starMenu.SetActive(true);
                menuIsOpen = true;
                SetStars();
                CalculateStarAmount();
            }
        }

        private void SetStars()
        {
            
            leftNoStar = GameObject.FindGameObjectWithTag("l_ns");
            midNoStar = GameObject.FindGameObjectWithTag("m_ns");
            rightNoStar = GameObject.FindGameObjectWithTag("r_ns");
            noStars[0] = leftNoStar;
            noStars[1] = midNoStar;
            noStars[2] = rightNoStar;
            
            leftStar = GameObject.FindGameObjectWithTag("leftStar");
            midStar = GameObject.FindGameObjectWithTag("midStar");
            rightStar = GameObject.FindGameObjectWithTag("rightStar"); 
            stars[0] = leftStar;
            stars[1] = midStar; 
            stars[2] = rightStar;
        }

        private void CalculateStarAmount()
        {
            totalSoapAmount = _countManager.totalAmount;
            remainingSoapCount = _countManager.RemainingTotalAmount();

            _percentage = float.Parse(remainingSoapCount.ToString()) /
                float.Parse(totalSoapAmount.ToString()) * 100f;

            if (_percentage >= 0f && _percentage < 40f) // one star // maybe can add no star option
            {
                noStars[0].gameObject.SetActive(false);
                noStars[1].gameObject.SetActive(true);
                noStars[2].gameObject.SetActive(true);
                stars[0].gameObject.SetActive(true);
                stars[1].gameObject.SetActive(false);
                stars[2].gameObject.SetActive(false);
            }
            else if (_percentage >= 40f && _percentage < 70f) // two stars
            {
                noStars[0].gameObject.SetActive(false);
                noStars[1].gameObject.SetActive(false);
                noStars[2].gameObject.SetActive(true);
                stars[0].gameObject.SetActive(true);
                stars[1].gameObject.SetActive(true);
                stars[2].gameObject.SetActive(false);
            }
            else if (_percentage >= 70f && _percentage <= 100f) // three stars
            {
                noStars[0].gameObject.SetActive(false);
                noStars[1].gameObject.SetActive(false);
                noStars[2].gameObject.SetActive(false);
                stars[0].gameObject.SetActive(true);
                stars[1].gameObject.SetActive(true);
                stars[2].gameObject.SetActive(true);
            }

        }
    }
}
