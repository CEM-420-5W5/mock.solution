using System;
using mock.depart.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace mock.depart.Models
{

    public enum Cuteness
    {
        BarelyOk = 0,
        YouCanKeepIt,
        Amazing
    }

    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Cuteness CuteLevel { get; set; }
        public virtual CatOwner? CatOwner { get; set; }
    }

}

