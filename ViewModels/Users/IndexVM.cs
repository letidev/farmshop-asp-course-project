using FarmShop.Entities;
using System.Collections.Generic;

namespace FarmShop.ViewModels.Users {
    public class IndexVM {
        public List<User> Items { get; set; }

        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount { get; set; }

        public string Username { get; set; }
    }
}
