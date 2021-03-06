﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieGenreView
    {
        public Movie Movie { get; set; }
        public IEnumerable<Object> GenreList { get; set; }

        public String Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";
                else
                    return "New Movie";
            }
        }
    }
}