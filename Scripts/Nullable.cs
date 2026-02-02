using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using UnityEngine;

#nullable enable

public class Nullable
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty([NotNullWhen(false)] string? value)
    {
        return string.IsNullOrEmpty(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AssertNotNull<T>([NotNull] T? value, string paramName) where T : class
    {
        if (value == null)
        {
            throw new ArgumentNullException(paramName);
        }
    }
}
