module Homework_6.RoundingWorkflow

/// <summary>
/// Rounding Workflow
/// </summary>
type Builder(accuracy: int) =
    member this.Bind(x: float, f) = f (System.Math.Round(x, accuracy))
    member this.Return(x: float) = System.Math.Round(x, accuracy)
