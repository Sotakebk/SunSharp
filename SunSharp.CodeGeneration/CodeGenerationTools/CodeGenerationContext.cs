﻿using System;
using System.Text;

namespace SunSharp.CodeGeneration.CodeGenerationTools;

public class CodeGenerationContext
{
    private const int SpacesPerTab = 4;

    private readonly StringBuilder _sb;
    private int _tabs;

    public CodeGenerationContext()
    {
        _sb = new StringBuilder();
    }

    public string GetTabs()
    {
        return new string(' ', _tabs * SpacesPerTab);
    }

    public void AddIndent(Action action)
    {
        _tabs++;
        action();
        _tabs--;
    }

    public void AppendLine(string value = "")
    {
        if (string.IsNullOrWhiteSpace(value))
            _sb.AppendLine();
        else
            _sb.AppendLine(GetTabs() + value);
    }

    public void AppendLineNoTab(string value = "")
    {
        _sb.AppendLine(value);
    }

    public string GetBuiltString()
    {
        return _sb.ToString();
    }
}
