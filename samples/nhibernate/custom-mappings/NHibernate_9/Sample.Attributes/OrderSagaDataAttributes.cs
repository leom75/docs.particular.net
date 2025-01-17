﻿using NHibernate.Mapping.Attributes;
using NServiceBus;
using System;

#pragma warning disable NSB0012 // Saga data classes should inherit ContainSagaData

[Class]
public class OrderSagaDataAttributes :
    IContainSagaData
{
    [Id(Name = "Id")]
    public virtual Guid Id { get; set; }
    [Property]
    public virtual string OriginalMessageId { get; set; }
    [Property]
    public virtual string Originator { get; set; }
    [Property(Length = 100, Type = "AnsiString", Unique = true)]
    public virtual string OrderId { get; set; }
    [Version]
    public virtual int Version { get; set; }
    [ManyToOne(Cascade = "all-delete-orphan", Column = "FromLocation")]
    public virtual Location From { get; set; }
    [ManyToOne(Cascade = "all-delete-orphan", Column = "ToLocation")]
    public virtual Location To { get; set; }
    public virtual AmountInfo Total { get; set; }

    [Class(Table = "OrderSagaDataAttributes_Location")]
    public class Location
    {
        [Id(Name = "Id", Generator = "guid.comb")]
        public virtual Guid Id { get; set; }
        [Property]
        public virtual double Lat { get; set; }
        [Property]
        public virtual double Long { get; set; }
    }

    [Component(Name = "Total")]
    public class AmountInfo
    {
        [Property(Type = "AnsiString", Length = 3, Column = "Total_Currency")]
        public virtual string Currency { get; set; }
        [Property(Column = "Total_Amount")]
        public virtual decimal Amount { get; set; }
    }
}

#pragma warning restore NSB0012 // Saga data classes should inherit ContainSagaData