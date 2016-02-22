﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageWebbRH.Models
{
    public class Group<K, T>
    {
        public K Key;
        public IEnumerable<T> Values;
    }
}