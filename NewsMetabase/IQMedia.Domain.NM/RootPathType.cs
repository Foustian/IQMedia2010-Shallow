//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace IQMedia.Domain.NM
{
    public partial class RootPathType
    {
        #region Primitive Properties
    
        public virtual int ID
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual string Description
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<RootPath> RootPaths
        {
            get
            {
                if (_rootPaths == null)
                {
                    var newCollection = new FixupCollection<RootPath>();
                    newCollection.CollectionChanged += FixupRootPaths;
                    _rootPaths = newCollection;
                }
                return _rootPaths;
            }
            set
            {
                if (!ReferenceEquals(_rootPaths, value))
                {
                    var previousValue = _rootPaths as FixupCollection<RootPath>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupRootPaths;
                    }
                    _rootPaths = value;
                    var newValue = value as FixupCollection<RootPath>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupRootPaths;
                    }
                }
            }
        }
        private ICollection<RootPath> _rootPaths;

        #endregion
        #region Association Fixup
    
        private void FixupRootPaths(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (RootPath item in e.NewItems)
                {
                    item.RootPathType = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (RootPath item in e.OldItems)
                {
                    if (ReferenceEquals(item.RootPathType, this))
                    {
                        item.RootPathType = null;
                    }
                }
            }
        }

        #endregion
    }
}