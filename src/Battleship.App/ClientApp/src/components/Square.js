import React, { Component } from 'react';

function Square(props) {
    return (
        <div className={mapSquareStateToClass(props.squareState)}>
        </div>
    )
}

function mapSquareStateToClass(squareState) {
    if (squareState === 0) {
        return "square-empty"
    }
    if (squareState === 1) {
        return "square-missed"
    }
    if (squareState === 2) {
        return "square-ontarget"
    }
}

export default Square