﻿using Microsoft.Extensions.Telemetry.Testing.Metering;
using Microsoft.Extensions.Time.Testing;
using System.Diagnostics.Metrics;
using Xunit;

//The MetricCollector class can now record metric measurements along with timestamps.
//Additionally, the class offers the flexibility to use any desired time provider for
//accurate timestamp generation.

const string CounterName = "MyCounter";

var now = DateTimeOffset.Now;

#pragma warning disable TBD // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
var timeProvider = new FakeTimeProvider(now);
#pragma warning restore TBD // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

using var meter = new Meter(Guid.NewGuid().ToString());
var counter = meter.CreateCounter<long>(CounterName);
#pragma warning disable TBD // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
using var collector = new MetricCollector<long>(counter, timeProvider);
#pragma warning restore TBD // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

Assert.Empty(collector.GetMeasurementSnapshot());
Assert.Null(collector.LastMeasurement);

counter.Add(3);

Assert.Single(collector.GetMeasurementSnapshot());

counter.Add(21);
counter.Add(48);

// verify the update was recorded
Assert.Equal(counter, collector.Instrument);
Assert.NotNull(collector.LastMeasurement);

Assert.Same(collector.GetMeasurementSnapshot().Last(), collector.LastMeasurement);
Assert.Equal(48, collector.LastMeasurement.Value);
Assert.Empty(collector.LastMeasurement.Tags);
Assert.Equal(now, collector.LastMeasurement.Timestamp);

foreach (var item in collector.GetMeasurementSnapshot())
{
    Console.WriteLine(item.Value);
}