﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpInterviewQuestion
{
    public interface IBinarySearchTree
    {
        Node Root { get; set; }
        void Insert(Node node);
        void InOrderTreeWalk(Node node);
        Node TreeSearch(Node node, int key);
        Node MinimumTree(Node node);
        Node MaximumTree(Node node);
        void TreeDelete(int key);
    }
}
