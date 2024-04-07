﻿
using FluentValidation.Results;

namespace ProductAuditSystem.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
        
    }

    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        Errors = validationResult.ToDictionary();
    }
    public IDictionary<string, string[]>? Errors { get; set; }

}
