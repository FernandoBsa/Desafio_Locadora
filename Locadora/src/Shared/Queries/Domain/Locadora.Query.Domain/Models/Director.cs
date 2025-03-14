﻿using MongoDB.Bson.Serialization.Attributes;

namespace Locadora.Query.Domain.Models;

public class Director
{
    [BsonId]
    public string Id { get; set; }
    public string FullName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime DeleteAt { get; set; }
}