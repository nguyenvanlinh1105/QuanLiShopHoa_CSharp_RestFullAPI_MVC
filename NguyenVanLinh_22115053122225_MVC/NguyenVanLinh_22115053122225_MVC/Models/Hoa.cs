using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NguyenVanLinh_22115053122225_MVC.Models
{
    public class Hoa
    {
        public int MaH { get; set; }

        public int MaDM { get; set; }

        public string Ten { get; set; }

        public string Donvitinh { get; set; }

        public decimal Dongia { get; set; }

        public int Soluong { get; set; }

        public string MoTa { get; set; }

        public string Hinhanh { get; set; }
    }
}