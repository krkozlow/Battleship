import React, { Component, useCallback, useState, useEffect } from 'react';
import Player from "./Player";
import Grid from "./Grid";
import Generate from "../utils/shootDummyGenerator";

function Game(props) {
    const [sizeX, sizeY] = [10, 10];
    const [firstSimplePlayer, setFirstSimplePlayer] = useState(null);
    const [secondSimplePlayer, setSecondSimplePlayer] = useState(null);
    
    const [firstPlayerData, setFirstPlayerData] = useState(null);
    const [secondPlayerData, setSecondPlayerData] = useState(null);

    useEffect(() => {
        fetch(`Battleship/StartGame/${sizeX}/${sizeY}`, {method: "POST"})
            .then(results => results.json())
            .then(data => {
                setFirstSimplePlayer(data[0]);
                setSecondSimplePlayer(data[1]);
            });
    }, []);
    
    useEffect(() => {
        const shootInterval = setInterval(() => {
            if (!(firstSimplePlayer && secondSimplePlayer)) {
                return;
            }

            let [x, y] = [Generate(sizeX - 1), Generate(sizeY - 1)];

            fetch(`Battleship/Shoot/${x}/${y}`, {method: 'PUT'})
                .then(results => results.json())
                .then(data => {
                    if (firstSimplePlayer.id === data[0]?.id) {
                        setFirstPlayerData(data[0]);
                    }
                    if (secondSimplePlayer.id === data[1]?.id) {
                        setSecondPlayerData(data[1]);
                    }
                });
        }, 1000);
        return () => clearInterval(shootInterval);
    }, [firstSimplePlayer, secondSimplePlayer]);
         
        return (
            <div>
                <div className="title">
                    <h4>Battleship</h4>
                </div>
                <div className="game">
                    <div className="player-board">
                        <Grid className="grid-container"  squares={firstPlayerData?.squares || []}/>
                        <Player name={firstSimplePlayer?.name} score={firstPlayerData?.score || 0}/>
                    </div>
                    <div className="player-board">
                        <Grid className="grid-container" squares={secondPlayerData?.squares || []}/>
                        <Player name={secondSimplePlayer?.name} score={secondPlayerData?.score || 0}/>
                    </div>
                </div>
            </div>
        )
    }

export default Game;