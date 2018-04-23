#  How to use manual date-time scale options of an Axis


<p>This example demonstrates how to use manual date-time scale options of an X-axis.</p>
<p>The data aggregation is enabled automatically for the date-time scale on the X-axis in manual scale options.</p>
<p>When the <strong>Axis.DateTimeScaleOptions</strong>  property is set to <strong>ManualDateTimeScaleOptions </strong> you can manually define<strong> ManualDateTimeScaleOptions.GridAlignmen</strong>t, <strong>ManualDateTimeScaleOptions.MeasureUnit</strong>, and <strong>ManualDateTimeScaleOptions.AggregateFunction</strong>  properties.</p>
<p>To use the automatic date-time scale options, set the A<strong>xisX.DateTimeScaleOptions</strong>  property to <strong>AutomaticDateTimeScaleOptions</strong> and choose the appropriate <strong>AutomaticDateTimeScaleOptions.AggregateFunction.</strong></p>
<p>If you wish the axis scale to not be divided into intervals, and therefore aggregation cannot be applied to chart data, set the <strong>ManualDateTimeScaleOptions.AggregateFunction</strong>  property to <strong>None</strong>.</p>

<br/>


