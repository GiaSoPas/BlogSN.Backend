﻿using System;

namespace BlogSN.Backend.Exceptions;

public class NotFoundException: Exception
{
    public NotFoundException(string message): base(message) {}
    
    
}