import { useState, useEffect } from 'react';
import RankItems from './RankItems';

const RankItemsContainer = ({ dataType, imgArr }) => {

    const [itemData, setItemData] = useState(null);
    
    useEffect(() => { 
        if (dataType === 1) {
            fetch("/api/Item?itemType=1")
                .then((response) => response.json())
                .then((data) => {
                    setItemData(data);
                })
                .catch((error) => console.error("Error:", error));
        }
        else if (dataType === 2) {
            fetch("/api/Item?itemType=2")
                .then((response) => response.json())
                .then((data) => {
                    setItemData(data);
                })
                .catch((error) => console.error("Error:", error));
        }
    }, [dataType])

    return (
        <RankItems items={itemData} setItems={setItemData} dataType={dataType} imgArr={imgArr}  />
    )

}
export default RankItemsContainer;