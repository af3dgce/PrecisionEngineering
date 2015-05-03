﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColossalFramework;
using ColossalFramework.Math;
using PrecisionEngineering.Data;
using PrecisionEngineering.Utilities;
using UnityEngine;

namespace PrecisionEngineering.Rendering
{
	static class DistanceRenderer
	{

		public const float Size = 2f;

		public static Vector3 GetLabelWorldPosition(DistanceMeasurement distance)
		{

			return distance.Position;

		}

		public static void Render(RenderManager.CameraInfo cameraInfo, DistanceMeasurement distance)
		{

			var renderManager = RenderManager.instance;

			if (!distance.IsStraight || distance.HideOverlay)
				return;

			var minHeight = Mathf.Min(distance.StartPosition.y, distance.EndPosition.y);
			var maxHeight = Mathf.Max(distance.StartPosition.y, distance.EndPosition.y);

			renderManager.OverlayEffect.DrawSegment(cameraInfo,
				distance.Flags == MeasurementFlags.Primary ? Color.green : Color.yellow,
				new Segment3(distance.StartPosition, distance.EndPosition), Size, 1f,
				minHeight - 20f,
				maxHeight + 20f, true, true);

		}

	}
}
