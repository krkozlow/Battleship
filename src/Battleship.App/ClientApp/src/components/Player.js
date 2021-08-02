﻿import React, { Component } from 'react';

function Player(props) {
    return (
        <div className="player">
            <div>
                <span>{props.name}</span>
            </div>
            <div>
                <span>{props.points}</span>
            </div>
        </div>
    )
}

export default Player;