﻿using System;
using System.Globalization;
using System.Windows.Forms;
using PoshSec.Framework.Strings;

namespace PoshSec.Framework
{
    public class SystemListViewItem : ListViewItem
    {
        public SystemListViewItem(string name) : base(name)
        {
            ImageIndex = 2;
            Text = name;
            SubItems.Add(new ListViewSubItem(this,string.Empty){Name = "ip"}); 
            SubItems.Add(new ListViewSubItem(this,string.Empty){Name = "mac"});
            SubItems.Add(new ListViewSubItem(this,string.Empty){Name = "description"});
            SubItems.Add(new ListViewSubItem(this,string.Empty){Name = "status"});
            SubItems.Add(new ListViewSubItem(this,string.Empty){Name = "installed"});
            SubItems.Add(new ListViewSubItem(this,string.Empty){Name = "alerts"});
            SubItems.Add(new ListViewSubItem(this,string.Empty){Name = "lastscanned"});
        }

        public string IpAddress
        {
            get => SubItems["ip"].Text;
            set => SubItems["ip"].Text = value;
        }

        public string MacAddress
        {
            get => SubItems["mac"].Text;
            set => SubItems["mac"].Text = value;
        }

        public string Description
        {
            get => SubItems["description"].Text;
            set => SubItems["description"].Text = value;
        }

        public string Status
        {
            get => SubItems["status"].Text;
            set => SubItems["status"].Text = value;
        }

        public string ClientInstalled
        {
            get => SubItems["installed"].Text;
            set => SubItems["installed"].Text = value;
        }

        public int Alerts
        {
            get => int.Parse(SubItems["alerts"].Text);
            set => SubItems["alerts"].Text = value.ToString();
        }

        public DateTime LastScanned
        {
            get => DateTime.Parse(SubItems["lastscanned"].Text);
            set => SubItems["lastscanned"].Text = value.ToString(StringValue.TimeFormat);
        }
    }
}