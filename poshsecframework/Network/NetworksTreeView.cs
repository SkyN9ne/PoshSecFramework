﻿using System;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;
using PoshSec.Framework.Strings;

namespace PoshSec.Framework
{
    public class NetworksTreeView : TreeView
    {
        public bool IsValid(string name)
        {
            var rtn = true;
            var idx = 0;
            var rootnode = Nodes[0];
            while (idx < rootnode.Nodes.Count && rtn)
            {
                var node = rootnode.Nodes[idx];
                if (node.Text == name) rtn = false;
                idx++;
            }

            return rtn;
        }

        public void Add(string name, NetworkType type)
        {
            switch (type)
            {
                case NetworkType.Local:
                    Nodes[0].Nodes.Add(new LocalNetworkTreeNode(name));
                    break;
                case NetworkType.Domain:
                    Nodes[0].Nodes.Add(new DomainNetworkTreeNode(name));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void Load(Networks networks)
        {
            Nodes[0].Nodes.Clear();
            foreach (var network in networks)
            {
                switch (network)
                {
                    case LocalNetwork _:
                        Add(network.Name, NetworkType.Local);
                        break;
                    case DomainNetwork _:
                        Add(network.Name, NetworkType.Domain);
                        break;
                }
            }
        }
    }
}
