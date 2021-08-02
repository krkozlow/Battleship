import React, { Component } from 'react';
import Square from "./Square";

function Grid(props) {
    let gridToRender = [];
    if(props.squares) {
        gridToRender = props.squares.map((row, i) => {
            let toReturn = row.map((square, j) => {
                return <Square key={i + "_" + j} squareState={square} />
            })

            return toReturn;
        })
        console.log(gridToRender)
        }
        return (
            <div className="grid-container">
                {
                    gridToRender
                }
            </div>
        )
}

export default Grid;