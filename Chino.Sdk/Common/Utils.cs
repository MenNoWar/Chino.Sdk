//-----------------------------------------------------------------------
// <copyright file="Utils.cs" company="Chino.IO and NursIt.Institute" />
// Copyright (c) Chino.IO and NursIt.Institute. All rights reserved.
// </copyright>
// <author>P. Kaatz, Kaatz@nursit.institute</author>
// <warranty>
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </warranty>
//-----------------------------------------------------------------------

namespace Chino.Sdk
{
    using Newtonsoft.Json;
    using RestSharp;
    using System;

    /// <summary>
    /// Utility class
    /// </summary>
    public class Utils
    {
        //public static Type StringToType(string typeString)
        //{
        //    switch (typeString)
        //    {
        //        case "string":
        //            return typeof(string);
        //        case "integer":
        //            return typeof(int);
        //        case "boolean":
        //            return typeof(bool);
        //        case "float":
        //            return typeof(double);
        //        case "datetime":
        //        case "date":
        //        case "time":
        //            return typeof(DateTime);
        //        case "blob":
        //            return typeof(byte[]);
        //    }

        //    throw new ChinoApiException("error, invalid type: " + typeString + ".");
        //}

        //public static String TypeToString(Type t)
        //{
        //    if (t == typeof(String) || t == typeof(string))
        //    {
        //        return "string";
        //    }
        //    else if (t == typeof(int) || t == typeof(Int32) || t == typeof(Int16) || t == typeof(Int64))
        //    {
        //        return "integer";
        //    }
        //    else if (t == typeof(bool) || t == typeof(Boolean))
        //    {
        //        return "boolean";
        //    }
        //    else if (t == typeof(float) || t == typeof(double) || t == typeof(Double))
        //    {
        //        return "float";
        //    }
        //    else if (t == typeof(DateTime))
        //    {
        //        return "datetime";
        //    }
        //    else if (t == typeof(TimeSpan))
        //    {
        //        return "datetime";
        //    }
        //    else if (t == typeof(FileStream))
        //    {
        //        return "blob";
        //    }
        //    else
        //    {
        //        throw new ChinoApiException("error, invalid type: " + t + ".");
        //    }
        //}
        /// <summary>
        /// The FieldTypeToCLRType
        /// </summary>
        /// <param name="type">The <see cref="SchemaFieldType"/></param>
        /// <returns>The <see cref="Type"/></returns>
        public static Type FieldTypeToCLRType(SchemaFieldType type)
        {
            switch (type)
            {
                case SchemaFieldType.integer:
                    return typeof(int);
                case SchemaFieldType.@float:
                    return typeof(float);
                case SchemaFieldType.text:
                case SchemaFieldType.@string:
                case SchemaFieldType.base64:
                case SchemaFieldType.json:
                    return typeof(string);
                case SchemaFieldType.boolean:
                    return typeof(bool);
                case SchemaFieldType.date:
                case SchemaFieldType.time:
                case SchemaFieldType.datetime:
                    return typeof(DateTime);
                case SchemaFieldType.blob:
                    return typeof(byte[]);
                default:
                    throw new ChinoApiException(string.Format("Not recognized Chino-Type: \"{0}\"", type));
            }
        }

        /// <summary>
        /// The CLRTypeToFieldType
        /// </summary>
        /// <param name="type">The <see cref="Type"/></param>
        /// <returns>The <see cref="SchemaFieldType"/></returns>
        public static SchemaFieldType CLRTypeToFieldType(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int64:
                case TypeCode.Int32:
                    return SchemaFieldType.integer;
                case TypeCode.Decimal:
                case TypeCode.Double:
                    return SchemaFieldType.@float;
                case TypeCode.String:
                case TypeCode.Char:
                    return SchemaFieldType.@string;
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.SByte:
                    return SchemaFieldType.boolean;
                case TypeCode.DateTime:
                    return SchemaFieldType.datetime;
            }

            // when reached here, none of the above types apply, so let's guess..
            if (type == typeof(byte[]))
            {
                return SchemaFieldType.blob;
            }
            else if (type == typeof(Nullable<DateTime>))
            {
                return SchemaFieldType.datetime;
            } else if (type == typeof(Nullable<int>))
            {
                return SchemaFieldType.integer;
            } else if (type == typeof(Nullable<bool>))
            {
                return SchemaFieldType.boolean;
            }

            throw new ChinoApiException(string.Format("Not recognized CLR-Type: \"{0}\"", type.Name));
        }

        /// <summary>
        /// Serialize an object to json with correct javascript date-time format
        /// </summary>
        /// <param name="obj">the object to serialize</param>
        /// <returns>the string representation of the Json-Object</returns>
        public static string SerializeObject(object obj)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:ss"
            };

            return JsonConvert.SerializeObject(obj, jsonSettings);
        }

        /// <summary>
        /// The SetJsonBody
        /// </summary>
        /// <param name="request">The <see cref="IRestRequest"/></param>
        /// <param name="bodyValue">The <see cref="object"/></param>
        public static void SetJsonBody(IRestRequest request, object bodyValue)
        {
            request.AddParameter("Application/Json", SerializeObject(bodyValue), ParameterType.RequestBody);
        }
    }
}
