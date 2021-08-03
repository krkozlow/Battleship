import React, { Component } from 'react';
import Square from "./Square";

function Grid(props) {
    if (!(props && props.squares)) {
        return (
            <div>
            </div>
        )
    }
    
    let gridToRender = [];
    gridToRender = props.squares.map((row, i) => {
        return  row.map((square, j) => {
            return <Square key={i + "_" + j} squareState={square} />
        })
    })
    return (
        <div className="grid-container">
            {
                gridToRender
            }
        </div>
    )
}

export default Grid;