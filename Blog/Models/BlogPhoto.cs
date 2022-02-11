using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPhoto
    {
        //set the first property of the class (BlogPhotoId) to be the Public Key (PK)
        [Key]
        public int BlogPhotoId { get; set; }
        public string Title { get; set; }
        //create a constructor for storing photos as an array of bytes
        public byte[] Photo { get; set; }
    }
}