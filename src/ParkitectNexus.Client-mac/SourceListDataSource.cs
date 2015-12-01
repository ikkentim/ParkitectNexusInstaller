﻿using System;
using MonoMac.AppKit;
using MonoMac.Foundation;
using System.Collections.Generic;

namespace ParkitectNexus.Clientmac
{

    public class SourceListDataSource : NSOutlineViewDataSource
    {
        #region Private Variables

        private SourceListView _controller;

        #endregion

        #region Public Variables

        public List<SourceListItem> Items = new List<SourceListItem>();

        #endregion

        #region Constructors

        public SourceListDataSource(SourceListView controller)
        {
            // Initialize
            this._controller = controller;
        }

        #endregion

        #region Override Properties

        public override int GetChildrenCount(NSOutlineView outlineView, NSObject item)
        {
            if(item == null)
            {
                return Items.Count;
            }
            else
            {
                return ((SourceListItem)item).Count;
            }
        }

        public override bool ItemExpandable(NSOutlineView outlineView, NSObject item)
        {
            return ((SourceListItem)item).HasChildren;
        }

        public override NSObject GetChild(NSOutlineView outlineView, int childIndex, NSObject item)
        {
            if(item == null)
            {
                return Items[(int)childIndex];
            }
            else
            {
                return ((SourceListItem)item)[(int)childIndex]; 
            }
        }

        public override NSObject GetObjectValue(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
        {
            return new NSString(((SourceListItem)item).Title);
        }

        #endregion

        #region Internal Methods

        internal SourceListItem ItemForRow(int row)
        {
            int index = 0;

            // Look at each group
            foreach(SourceListItem item in Items)
            {
                // Is the row inside this group?
                if(row >= index && row <= (index + item.Count))
                {
                    return item[row - index - 1];
                }

                // Move index
                index += item.Count + 1;
            }

            // Not found 
            return null;
        }

        #endregion
    }
}

