module Homework_2.TreeMap

type BinaryTree<'a> =
    | Tree of 'a * BinaryTree<'a> * BinaryTree<'a>
    | Tip of 'a

/// <summary>
/// A function that applies a function to each element of a binary tree
/// </summary>
/// <param name="func">Function to apply</param>
/// <param name="tree">Binary tree</param>
/// <returns>New binary tree</returns>
let rec map func tree =
    let rec treeMatch tree =
        match tree with
        | Tree(value, l, r) -> Tree(func value, treeMatch l, treeMatch r)
        | Tip a -> Tip(func a)

    treeMatch tree
