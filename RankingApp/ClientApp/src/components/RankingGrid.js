const RankingGrid = ({ items, imgArr }) => {

    const rankingGrid = [];
    const cellCollectionTop = [];
    const cellCollectionMiddle = [];
    const cellCollectionBottom = [];
    const cellCollectionWorst = [];

    

    function createCellForRows() {

        const maxRows = 4;
        for (var row = 1; row <= maxRows; row++) {
            createCellsForRows(row);
        }
    }

    function createRowsForGrid() {
        rankingGrid.push(<div className="rank-row top-tier">{cellCollectionTop}</div>);
        rankingGrid.push(<div className="rank-row middle-tier">{cellCollectionMiddle}</div>);
        rankingGrid.push(<div className="rank-row bottom-tier">{cellCollectionBottom}</div>);
        rankingGrid.push(<div className="rank-row worst-tier">{cellCollectionWorst}</div>);

        return rankingGrid;
    }

    function createRankingGrid() {
        createCellForRows();
        return createRowsForGrid();
    }

    return (
        <div className="rankings">
            {createRankingGrid() }
        </div>

    )

}
export default RankingGrid;