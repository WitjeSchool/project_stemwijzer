  <?php
    $host = 'localhost';
    $port = 4406; // jouw poort
    $dbname = 'stemwijzer';
    $username = 'root';
    $password = '';
     


    try {
        $pdo = new PDO("mysql:host=$host;port=$port;dbname=$dbname;charset=utf8mb4", $username, $password);
        $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    } catch (PDOException $e) {
        die("Verbindingsfout: " . $e->getMessage());
    }



    ?>
    <HTML lang="NL">
<!DOCTYPE html>
    <head>
        <title>Stemwijzer</title>
        <link rel="Stylesheet" href="Stemwijzer.css"/>
        <script src="stemwijzer.js"></script>
       
    </head>
    <body>
        <section>   
            <nav class="navbar">
            <div class="navdiv">    
            <a href="homepage.html">
                
                
                <img src="image/logo-neutraal-kieslab-donkerblauw.svg" class="logoA" width="70" height="70"/>
            </a>
            <ul>
                <button class="knopA">
                    <a class="buttonNav" href="stemwijzer menu.html">Stemwijzer</a>
                </button>
                <button class="knopB">
                    <a class="buttonNav" href="info Partijen.html">Informatie Partijen</a>
                </button>
                <button class="knopC">
                        <a class="buttonNav" href="over ons.html">Over ons</a>
                    </button>
                    <button class="knopD">
                        <a class="buttonNav" href="Inlog Regri.html">Inlog</a>
                </button>
            </ul>
            </div>
            </nav>
            <article>
                
<div id="vragen-container">
    <!-- Eerste vraag (zichtbaar bij start) -->
    <div class="vraag actief">
        <div class="VragenSW">1. De regering moet ervoor zorgen dat de hoeveelheid vee 
            <br>minstens de helft kleiner wordt.</div>
        <button class="KnopE">Wat vinden partijen hiervan!</button>
        <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
    </div>
    <div class="vraag">
        <div class="VragenSW">2. De accijns op benzine, gas en diesel moet omlaag.</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
     <div class="knoppen-container">
    <button class="Eens">Eens</button>
    <button class="geenidee">Geen van beide</button>
    <button class="Oneens">Oneens</button>
    </div>
  </div>

  <div class="vraag">
    <div class="VragenSW">3. Het eigen risico bij zorgverzekeringen moet worden afgeschaft.</div>
    <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>
</div>

 <div class="vraag">
        <div class="VragenSW">4. Elke regio in Nederland moet een vast aantal mensen in de 2de kamer krijgen.</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

  <div class="vraag">
        <div class="VragenSW">5. Mensen vanaf 65 jaar moeten gratis met trein, tram en bus kunnen reizen.</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

  <div class="vraag">
        <div class="VragenSW">6. De regering moet meer investeren in opslag van CO2 onder de grond..</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

  <div class="vraag">
        <div class="VragenSW">7. De regering moet ervoor zorgen dat Surinamers zonder visum naar Nederland kunnen reizen. </div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

<div class="vraag">
        <div class="VragenSW">8. Er moet een wet komen waarin staat dat Nederland altijd 2% van het bruto binnenlands product uitgeeft aan defensie.</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

  <div class="vraag">
        <div class="VragenSW">9. De overheid moet meer geld geven aan scholen voor lessen in kunst en cultuur.</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

  <div class="vraag">
        <div class="VragenSW">10. In Nederland moeten meer kerncentrales komen.</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

  <div class="vraag">
        <div class="VragenSW">11. De Belasting op vliegreizen moet omhoog.</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

  <div class="vraag">
        <div class="VragenSW">12. Huurders moeten het recht krijgen om hun sociale huurwoning te kopen van de woningcorporatie.</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

  <div class="vraag">
        <div class="VragenSW">13. Kinderopvang mag alleen worden aangeboden door organisaties die geen winst maken.</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

  <div class="vraag">
        <div class="VragenSW">14. Als een vluchteling in Nederland mag blijven, mag het gezin nu naar Nederland komen. De regering moet dat beperken.</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

  <div class="vraag">
        <div class="VragenSW">15. De belasting op vermogen boven 57000 euro moet omhoog.</div>
     <button class="KnopE">Wat vinden partijen hiervan!</button>
    <div class="knoppen-container">
            <button class="Eens">Eens</button>
            <button class="geenidee">Geen van beide</button>
            <button class="Oneens">Oneens</button>
        </div>
  </div>

</div>

            </article>
            <div class="lijn-footer"></div>
            <footer class="footerbar">
            <div class="footerdiv">
            <img src="image/logo-neutraal-kieslab-donkerblauw.svg" class="logoB" width="80" height="80"/>
            <ul>
                <a href="https://www.facebook.com/facebook/" target="_blank">
                    <img src="image/facebook logo.png" width="70" height="70"/>
                </a>
                <a href="https://x.com/" target="_blank">
                    <img src="image/twiiter logo.png" width="70" height="70"/>
                </a>
                <a href="https://www.instagram.com/" target="_blank">
                    <img src="image/instagram logo.png" width="70" height="70"/>
                </a>
                <a class="linkedin" href="https://www.linkedin.com/" target="_blank">
                    <img src="image/LinkedIn logo.png" width="70" height="70"/>
                </a>
            </ul>
            </div>
            </footer>
        </section>
    </body>
</html>