import React, { Component } from 'react';
import Player from "./Player";
import Grid from "./Grid";

function Game(props) {
    const [firstPlayerSquares, setFirstPlayer] = React.useState(null);
    const [secondPlayerSquares, setSecondPlayer] = React.useState(null);

    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' }
    };
    React.useEffect(() => {
        fetch('Battleship/StartGame', requestOptions)
            .then(results => results.json())
            .then(data => {
                setFirstPlayer(data?.players[0]?.grid?.squares);
                setSecondPlayer(data?.players[1]?.grid?.squares);
            });
    }, []);

    return (
        <div>
            <div className="title">
                <h4>Battleship</h4>
            </div>
            <div className="game">
                <div className="player-board">
                    <Grid className="grid-container" squares={[[0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1]]} />
                    <Player name={"first name"} points={10} />
                </div>
                <div className="player-board">
                    <Grid className="grid-container" squares={[[0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1], [0, 0, 2, 1, 1, 0, 0, 2, 1, 1]]} />
                    <Player name={"second player"} points={10} />
                </div>
            </div>
        </div>
    )
}

export default Game;