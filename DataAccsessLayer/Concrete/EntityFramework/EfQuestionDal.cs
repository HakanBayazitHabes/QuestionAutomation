﻿using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete.EntityFramework
{
    public class EfQuestionDal:EfEntityRepositoryBase<Question,Context>,IQuestionDal
    {
    }
}
