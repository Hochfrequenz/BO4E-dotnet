﻿using System;
using System.Numerics;
using System.Text;

namespace BO4E.Encryption
{
    internal static class ByteArrayExtensions
    {
        // https://codereview.stackexchange.com/a/14101/207271
        internal static string ToBaseXString(this byte[] toConvert, string alphabet)
        {
            if (string.IsNullOrWhiteSpace(alphabet))
                throw new ArgumentException($"{nameof(alphabet)} must not be empty but was '{alphabet}'.");
            var dividend = new BigInteger(toConvert);
            var builder = new StringBuilder();
            while (dividend != 0)
            {
                dividend = BigInteger.DivRem(dividend, alphabet.Length, out var remainder);
                builder.Insert(0, alphabet[Math.Abs((int) remainder)]);
            }

            return builder.ToString();
        }
    }
}