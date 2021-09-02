<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128570264/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T112240)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
#  How to use manual date-time scale options of an Axis


<p>This example demonstrates how to use manual date-time scale options of an X-axis.</p>
<p>The data aggregation is enabled automatically for the date-time scale on the X-axis in manual scale options.</p>
<p>When the <strong>Axis.DateTimeScaleOptions</strong>  property is set to <strong>ManualDateTimeScaleOptions </strong> you can manually define<strong> ManualDateTimeScaleOptions.GridAlignmen</strong>t, <strong>ManualDateTimeScaleOptions.MeasureUnit</strong>, and <strong>ManualDateTimeScaleOptions.AggregateFunction</strong>  properties.</p>
<p>To use the automatic date-time scale options, set the A<strong>xisX.DateTimeScaleOptions</strong>  property to <strong>AutomaticDateTimeScaleOptions</strong> and choose the appropriate <strong>AutomaticDateTimeScaleOptions.AggregateFunction.</strong></p>
<p>If you wish the axis scale to not be divided into intervals, and therefore aggregation cannot be applied to chart data, set the <strong>ManualDateTimeScaleOptions.AggregateFunction</strong>  property to <strong>None</strong>.</p>

<br/>


