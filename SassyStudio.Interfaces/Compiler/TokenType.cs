﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SassyStudio
{
    public enum TokenType
    {
        None,
        StartOfFile,
        EndOfFile,
        Unknown,
        Whitespace,
        String,
        BadString,
        Hash,
        Dollar,
        SuffixMatch,
        OpenFunctionBrace,
        CloseFunctionBrace,
        Asterisk,
        SubstringMatch,
        Plus,
        Number,
        Comma,
        Minus,
        Identifier,
        CloseHtmlComment,
        Period,
        Slash,
        Colon,
        Semicolon,
        OpenHtmlComment,
        OpenBrace,
        CloseBrace,
        OpenCurlyBrace,
        CloseCurlyBrace,
        Pipe,
        DashMatch,
        Column,
        Tilde,
        IncludeMatch,
        OpenCssComment,
        CommentText,
        CppComment,
        CloseCssComment,
        At,
        UnicodeRange,
        Function,
        Bang,
        Ampersand,
        OpenInterpolation,
        CloseInterpolation,
        LessThan,
        GreaterThan,
        DoubleEqual,
        NotEqual,
        GreaterThanEqual,
        LessThanEqual,
        Equal,
        DoubleColon,
        PrefixMatch,
        Caret,
        PercentSign
    }
}