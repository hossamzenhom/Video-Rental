using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRental.Models.ViewModels
{
    public class ViewModelMoviesForm
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}