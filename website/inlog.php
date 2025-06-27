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
    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $gebruikersnaam = $_POST['GebruikersnaamInput'] ?? '';
        $wachtwoord = $_POST['WachtwoordInput'] ?? '';
        // Validatie
        if (empty($gebruikersnaam) || empty($wachtwoord)) {
            die("Gebruikersnaam en wachtwoord zijn verplicht.");
        }
    }
    ?>
    <HTML lang="NL">
<!DOCTYPE html>
    <head>
        <title>Stemwijzer</title>
        <link rel="Stylesheet" href="inlog.css"/>
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
                

                <script>
                    document.getElementById('knopD').addEventListener('click', function () {
                    // Simuleer succesvolle login
                    localStorage.setItem('isLoggedIn', 'true');
                    // Ga terug naar hoofdpagina
                    window.location.href = 'Homepage.html';
                    });
                </script>
            </ul>
            </div>
            </nav>
            <article>
            <form id="loginForm" onsubmit="return controleerInvoer()">
                <div id="GebruikersnaamVak">
                    <div id="GebruikersnaamText">Gebruikersnaam:</div>
                    <input id="GebruikersnaamInput" type="text" maxlength="15" required>
                </div>
                <div id="WachtwoordVak">
                    <div id="WachtwoordText">Wachtwoord:</div>
                    <input id="WachtwoordInput" type="password" maxlength="20" required>
                </div>
                <input type="submit" id="KnopE" value="Inloggen">
            </form>
            <div id="RegristratieText">Nog geen account?</div>
            <div id="RegristratieKnop">
                <a href="regridatabase.php">Aanmelden</a>
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
        <script>    
            function controleerInvoer() {
                const gebruikersnaam = document.getElementById('GebruikersnaamInput').value.trim();
                const wachtwoord = document.getElementById('WachtwoordInput').value.trim();

            if (gebruikersnaam === "" || wachtwoord === "") {
                alert("Vul zowel een gebruikersnaam als wachtwoord in.");
            return false;
            }

                window.location.href = "Homepage.html";
            return false;
            }

             // Functie om login status te controleren en button aan te passen
            function checkLoginStatus() {
                const isLoggedIn = localStorage.getItem('isLoggedIn');
                const navLink = document.getElementById('navLink');
                const loginButton = document.getElementById('loginButton');
                
                if (isLoggedIn === 'true') {	
                    navLink.textContent = 'Profiel';
                    navLink.href = 'profiel view.html';
                    loginButton.className = 'knopE'; // Verander CSS class indien nodig
                    loginButton.textContent = 'Uitlog';
                } else {
                    navLink.textContent = 'Inlog';
                    navLink.href = 'Inlog Regri.html';
                    loginButton.className = 'knopD';
                }
            }

            // Functie die aangeroepen wordt na succesvol inloggen
            function handleSuccessfulLogin() {
                localStorage.setItem('isLoggedIn', 'true');
                checkLoginStatus(); // Update de button direct
            }

            // Functie voor uitloggen
            function handleLogout() {
                localStorage.removeItem('isLoggedIn');
                checkLoginStatus(); // Update de button direct
            }

            // Luister naar storage events (voor als er in een ander tabblad wordt ingelogd)
            window.addEventListener('storage', function(e) {
                if (e.key === 'isLoggedIn') {
                    checkLoginStatus();
                }
            });

            window.onload = function() {
                checkLoginStatus();
            };
        </script>
    </body>
</html> 