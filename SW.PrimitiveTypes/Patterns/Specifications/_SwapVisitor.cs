﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SW.PrimitiveTypes
{
    class SwapVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public SwapVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }

        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }
}
