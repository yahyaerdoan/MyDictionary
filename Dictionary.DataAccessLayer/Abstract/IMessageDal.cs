﻿using Dictionary.DataAccessLayer.Abstract.IGenericRepositories;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericRepository<Message>
    {
    }
}
