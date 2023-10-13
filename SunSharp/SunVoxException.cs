﻿using System;

namespace SunSharp
{
    public sealed class SunVoxException : Exception
    {
        private readonly uint _code;
        private readonly string? _method;

        public SunVoxException(uint code, string? method = null)
        {
            _code = code;
            _method = method;
        }

        public SunVoxException(int code, string? method = null) : this((uint)code, method)
        {
        }

        public override string Message => $"Error code: {_code:X}, method: '{_method ?? "unknown"}'.";
    }
}
