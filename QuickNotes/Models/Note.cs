using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuickNotes.Models
{
    public class Note
    {
        public long Id { get; set; }
        private string _key;
        public string Key
        {
            get
            {
                if (_key == null)
                {
                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value; }
        }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter body text.")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public DateTime Posted { get; set; }
    }
}