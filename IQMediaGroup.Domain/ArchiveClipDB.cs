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

namespace IQMediaGroup.Domain
{
    public partial class ArchiveClipDB
    {
        #region Primitive Properties
    
        public System.Guid ClipID
        {
            get;
            set;
        }
    
        public System.DateTime ClipCreationDate
        {
            get;
            set;
        }
    
        public string Category
        {
            get;
            set;
        }
    
        public string Description
        {
            get;
            set;
        }
    
        public string ClipTitle
        {
            get;
            set;
        }
    
        public string ClipLogo
        {
            get;
            set;
        }
    
        public System.DateTime ClipDate
        {
            get;
            set;
        }
    
        public string ClipThumbnailImagePath
        {
            get;
            set;
        }
    
        public double gmt_adj
        {
            get;
            set;
        }
    
        public double dst_adj
        {
            get;
            set;
        }
    
        public int StartOffset
        {
            get;
            set;
        }
    
        public string Keywords
        {
            get;
            set;
        }
    
        public string ClipMeta
        {
            get;
            set;
        }

        #endregion
    }
}