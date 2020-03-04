using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACEntrepidusTest19.Consts
{
    public static class RegExConsts
    {
        public const string CedulaRegEx = @"^[A-Z]{1}[0-9]{1-15}$";
        public const string NameRegEx = @"^[ÁÉÍÓÚÑáéíóúña-zA-Z0-9 ,'._-]*$";
        public const string UserNameRegEx = @"^[a-zA-Z0-9]*$";
        public const string DocumentRegEx = @"^[A-Za-z0-9.-]+$";
        public const string AddressRegEx = @"^[ÁÉÍÓÚÑáéíóúña-zA-Z0-9 \n\r\)\(,'.:;_-]*$";
        public const string MLCommentsRegEx = @"^[ÁÉÍÓÚÑáéíóúña-zA-Z0-9 \n\r\)\(,'.:;_/%*^-]*$"; //MultiLine
        public const string SLCommentsRegEx = @"^[ÁÉÍÓÚÑáéíóúña-zA-Z0-9 \)\(,'.:;_/%*^-]*$"; //SingleLine
        public const string FloatRegEx = @"^[0-9]*(?:\.[0-9]*)?$";
    }
}