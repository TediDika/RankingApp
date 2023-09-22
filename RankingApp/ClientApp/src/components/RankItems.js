/* eslint-disable jsx-a11y/alt-text */
import {useEffect, useState } from 'react';
import MovieImageArr from "./MovieImages.js";
import RankingGrid from "./RankingGrid";
import ItemCollection from "./ItemCollection";

const RankItems = ({items, setItems, dataType, imgArr }) => {


    const [update, setUpdate] = useState(false);

    async function Reload() {

        const updatedItems = items.map(item => ({ ...item, ranking: 0 }));
        for (const item of updatedItems) {
            let response;
            try {
                if (dataType === 1) {
                    response = await fetch(`/api/Item/${item.id}`, {
                        method: 'PUT',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(item),
                    });
                }
                else if (dataType === 2) {
                    response = await fetch(`/api/Item/${item.id}`, {
                        method: 'PUT',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(item),
                    });
                }

                if (!response.ok) {
                    console.error('Error:', response.status);
                }
            } catch (error) {
                console.error('Error:', error);
            }
        }

        setItems(updatedItems);
        setUpdate(prevState => !prevState);
    }

    function drag(ev) {
        ev.dataTransfer.setData("text", ev.target.id);
    }

    function allowDrop(ev) {
        ev.preventDefault();
    }

    async function drop(ev) {
        ev.preventDefault();
        const targetElm = ev.target;
        if (targetElm.nodeName === "IMG") {
            return false;
        }
        if (targetElm.childNodes.length === 0) {
            var data = parseInt(ev.dataTransfer.getData("text").substring(5));

            const updatedItem = items.find(item => item.id === parseInt(data));
            updatedItem.ranking = parseInt(targetElm.id.substring(5));

            let result;
            try {

                if (dataType === 1) {
                    result = await fetch(`/api/Item/${updatedItem.id}`, {
                        method: 'PUT',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(updatedItem),
                    });
                }
                else if (dataType === 2) {
                    result = await fetch(`/api/Item/${updatedItem.id}`, {
                        method: 'PUT',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(updatedItem),
                    });
                }

                if (result.ok) { 
                    const data = await result.text(); 

                    if (data) { 
                        const jsonData = JSON.parse(data); 
                        console.log(jsonData);
                    }
                } else {
                    console.error('Error:', result.status);
                }
                
                const responseAll = await fetch(`/api/Item`);
                const dataAll = await responseAll.json();
                setItems(dataAll);
                setUpdate(prevState => !prevState);
            } catch (error) {
                console.error('Error:', error);
            }
        }
    }

   async function getDataFromApi() {
       if (dataType === 1 || dataType === 2) {
           fetch(`/api/Item`)
               .then((results) => {
                   return results.json();
               })
               .then(data => {
                   setItems(data);
               })
               .catch((error) => console.error("Error:", error));
       }
    }

    useEffect(() => {
        getDataFromApi();
    },[update])

    return (
        (items != null)?
        <main>
            <RankingGrid items={items} imgArr={imgArr} drag={drag} allowDrop={allowDrop} drop={drop } />
            <ItemCollection items={items} drag={drag} imgArr={imgArr} />
                <button onClick={Reload} className="reload" style={{ "marginTop": "10px" }}><span className="text">Reload</span></button>
            </main>
        : <main>Loading...</main>
    )
}
export default RankItems;