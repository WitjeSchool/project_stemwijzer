window.onload = function () {
    const vragen = document.querySelectorAll('.vraag');
    let huidigeVraag = 0;
    let antwoorden = [];

    // Parse the raw data string
    const rawData = "vragen->123456789101112131415BBBoneenseenseenseenseenseensoneenseensoneenseensoneenseensoneenseensoneensSGPoneenseensoneensoneensoneensoneensoneenseensoneenseenseensoneensoneenseensoneensPVVoneenseenseensoneenseensoneensoneensoneensoneenseensoneenseenseenseenseensFVDoneenseensoneensoneenseensoneensoneenseenseenseenseensoneenseensoneenseensoneensNSConeenseensoneenseensoneensoneenseenseensoneenseenseensoneenseenseensoneensGL PVDAeens oneenseensoneensoneensoneenseenseenseensoneenseenseenseensoneenseensVVDoneenseensoneensoneensoneenseensoneenseensoneenseensoneenseensoneenseensoneensCDAoneenseensoneenseensoneensoneenseenseensoneenseenseenseenseenseensoneensD66eens oneensoneenseensoneenseenseenseenseenseenseenseenseensoneenseens";

    // Function to parse the raw data into structured format
    function parsePartyData(rawString) {
        const partijen = {};
        
        // Remove the "vragen->123456789101112131415" part
        const dataWithoutHeader = rawString.replace(/^vragen->[\d]+/, '');
        
        // Define party names in order they appear
        const partyNames = ['BBB', 'SGP', 'PVV', 'FVD', 'NSC', 'GL PVDA', 'VVD', 'CDA', 'D66'];
        
        let currentIndex = 0;
        
        partyNames.forEach(partyName => {
            const partyStart = dataWithoutHeader.indexOf(partyName, currentIndex);
            if (partyStart !== -1) {
                // Find the start of the answers (after party name)
                const answersStart = partyStart + partyName.length;
                
                // Find the next party name or end of string
                let answersEnd = dataWithoutHeader.length;
                const nextPartyIndex = partyNames.indexOf(partyName) + 1;
                if (nextPartyIndex < partyNames.length) {
                    const nextPartyStart = dataWithoutHeader.indexOf(partyNames[nextPartyIndex], answersStart);
                    if (nextPartyStart !== -1) {
                        answersEnd = nextPartyStart;
                    }
                }
                
                // Extract answers string
                const answersString = dataWithoutHeader.substring(answersStart, answersEnd);
                
                // Parse individual answers
                const positions = [];
                let i = 0;
                while (i < answersString.length && positions.length < 15) {
                    if (answersString.substring(i, i + 4) === 'eens') {
                        positions.push(1);
                        i += 4;
                    } else if (answersString.substring(i, i + 6) === 'oneens') {
                        positions.push(-1);
                        i += 6;
                    } else {
                        i++;
                    }
                }
                
                // Ensure we have exactly 15 positions
                while (positions.length < 15) {
                    positions.push(0); // Default to neutral if missing
                }
                
                partijen[partyName] = positions.slice(0, 15); // Take only first 15
                currentIndex = answersEnd;
            }
        });
        
        return partijen;
    }

    // Parse the party data
    const partijen = parsePartyData(rawData);
    
    // Log parsed data for verification
    console.log('Parsed party data:', partijen);

    function volgendeVraag(antwoord) {
        // Convert answer to numeric value for comparison
        let numericAnswer;
        if (antwoord === 'Eens') numericAnswer = 1;
        else if (antwoord === 'Oneens') numericAnswer = -1;
        else numericAnswer = 0; // Geen van beide

        antwoorden.push({
            text: antwoord,
            value: numericAnswer
        });

        // Verberg huidige vraag
        vragen[huidigeVraag].classList.remove('actief');

        // Volgende vraag tonen
        huidigeVraag++;
        if (huidigeVraag < vragen.length) {
            vragen[huidigeVraag].classList.add('actief');
        } else {
            toonResultaten();
        }
    }

    function berekenMatches() {
        const matches = {};
        
        for (const [partijNaam, posities] of Object.entries(partijen)) {
            let score = 0;
            let maxScore = 0;
            
            for (let i = 0; i < antwoorden.length; i++) {
                const userAnswer = antwoorden[i].value;
                const partijPosition = posities[i];
                
                // Skip if either answer is "geen van beide" (0)
                if (userAnswer !== 0 && partijPosition !== 0) {
                    maxScore += 2; // Maximum points per question
                    if (userAnswer === partijPosition) {
                        score += 2; // Full agreement
                    }
                    // No points for disagreement
                } else if (userAnswer === 0 && partijPosition === 0) {
                    maxScore += 1;
                    score += 1; // Both neutral
                }
            }
            
            // Calculate percentage match
            const percentage = maxScore > 0 ? Math.round((score / maxScore) * 100) : 0;
            matches[partijNaam] = {
                score: score,
                maxScore: maxScore,
                percentage: percentage
            };
        }
        
        // Sort by percentage (highest first)
        return Object.entries(matches)
            .sort(([,a], [,b]) => b.percentage - a.percentage)
            .map(([naam, data]) => ({ naam, ...data }));
    }

    function toonResultaten() {
        const matches = berekenMatches();
        const bestMatch = matches[0];
        
        document.getElementById('vragen-container').innerHTML = `
            <div class="resultaten">
                <h1 style="Color:white">Stemwijzer Resultaten</h1>
                <p style="Color:white">Bedankt voor het invullen van de stemwijzer!</p>
                
                <div class="best-match">
                    <h2 style="Color:white">🎯 Beste Match</h2>
                    <div class="match-card highlight">
                        <h3>${bestMatch.naam}</h3>
                        <div class="percentage">${bestMatch.percentage}% overeenkomst</div>
                        <div class="score-detail">${bestMatch.score}/${bestMatch.maxScore} punten</div>
                    </div>
                </div>
                
                <div class="all-matches">
                    <h3>Alle resultaten:</h3>
                    ${matches.map(match => `
                        <div class="match-card ${match === bestMatch ? 'highlight' : ''}">
                            <div class="match-info">
                                <span class="party-name">${match.naam}</span>
                                <span class="match-percentage">${match.percentage}%</span>
                            </div>
                            <div class="progress-bar">
                                <div class="progress-fill" style="width: ${match.percentage}%"></div>
                            </div>
                        </div>
                    `).join('')}
                </div>
                
                <div class="answers-summary">
                    <h3>Je antwoorden:</h3>
                    <ul>
                        ${antwoorden.map((antwoord, index) => `
                            <li>Vraag ${index + 1}: ${antwoord.text}</li>
                        `).join('')}
                    </ul>
                </div>
                
                <button onclick="location.reload()" style="Color:white">Opnieuw beginnen </button>
            </div>
        `;
        
    }

    // Event listeners per vraag toevoegen
    vragen.forEach(vraag => {
        const eensKnop = vraag.querySelector('.Eens');
        const geenIdeeKnop = vraag.querySelector('.geenidee');
        const oneensKnop = vraag.querySelector('.Oneens');

        if (eensKnop) eensKnop.addEventListener('click', () => volgendeVraag('Eens'));
        if (geenIdeeKnop) geenIdeeKnop.addEventListener('click', () => volgendeVraag('Geen van beide'));
        if (oneensKnop) oneensKnop.addEventListener('click', () => volgendeVraag('Oneens'));
    });
};