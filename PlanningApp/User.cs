﻿using System;

namespace PlanningApp
{
    [Serializable]
    public class User
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
    }
}