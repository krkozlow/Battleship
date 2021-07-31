import React, { Component } from 'react';

function Grid(props) {
    const [players, setPlayers] = React.useState(null);

    React.useEffect(() => {
        fetch('battleship')
            .then(results => results.json())
            .then(data => {
                const {players} = data.results;
                setPlayers(players);
            });
    }, []);
    return (
        <div>
        </div>
    );
}

export default Grid;
