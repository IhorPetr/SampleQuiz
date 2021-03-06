﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular5AspNetCoreProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular5AspNetCoreProject.Controllers
{
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        // GET api/question/all        
        [HttpGet("All/{quizId}")]
        public IActionResult All(int quizId)
        {
            var sampleResults = new List<ResultViewModel>();
            // add a first sample result            
            sampleResults.Add(new ResultViewModel()
            {
                Id = 1,
                QuizId = quizId,
                Text = "What do you value most in your life?",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });
            for (int i = 2; i <= 5; i++)
            {
                sampleResults.Add(new ResultViewModel()
                {
                Id = i,
                QuizId = quizId,
                Text = String.Format("Sample Question {0}", i),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
                }); 
            }
            // output the result in JSON format            
            return new JsonResult(sampleResults,new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
        }
    }
}
