//-----------------------------------------------------------------------
// <copyright file="chinoattribute.cs" company="Chino.IO and NursIt.Institute" />
// Copyright (c) Chino.IO and NursIt.Institute. All rights reserved.
// </copyright>
// <author>P. Kaatz, Kaatz@nursit.institute</author>
// <warranty>
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </warranty>
//-----------------------------------------------------------------------

namespace Chino.Sdk.Attributes
{
    using System;

    /// <summary>
    /// Attribute class to use when specifying a class for automatic schema creation 
    /// </summary>
    public class ChinoAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets a value indicating whether this field should be indexed when creating a schema from the class/type
        /// </summary>
        public bool Indexed { get; set; }

        /// <summary>
        /// Gets a value indicating whether the automatic estimated fieldtype should be overridden with the specified <seealso cref="FieldType"/>
        /// </summary>
        public bool OverrideAutomaticFieldType { get; private set; }

        private SchemaFieldType _fieldType = SchemaFieldType.@string;

        /// <summary>
        /// Gets or sets the <seealso cref="SchemaFieldType"/> to use for the generated field
        /// </summary>
        public SchemaFieldType FieldType
        {
            get { return _fieldType; }
            set
            {
                _fieldType = value;
                OverrideAutomaticFieldType = true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChinoAttribute"/> class
        /// </summary>
        public ChinoAttribute()
        {
            Generate = true;
            OverrideAutomaticFieldType = false;
        }

        /// <summary>
        /// the schema description, only applies to a type (not to a property)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the property name, only applies to a property (not to a type)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to generate or ignore a property/class
        /// </summary>
        public bool Generate { get; set; }
    }
}
