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
        $geboortedatum = $_POST['GeboorteDatumInput'] ?? '';
        $email = $_POST['EmailInput'] ?? '';
        $gebruikersnaam = $_POST['GebruikersnaamInput'] ?? '';
        $wachtwoord = $_POST['WachtwoordInput'] ?? '';
        $herhaalWachtwoord = $_POST['HerhaalWachtwoordInput'] ?? '';
        $voorwaarden = isset($_POST['algemenevoorwaardenInput']) ? 1 : 0;
        $privacy = isset($_POST['privacybeleidInput']) ? 1 : 0;

        // Controleer op dubbele gebruikers
        $sql = "SELECT gebruikersnaam, email FROM users WHERE gebruikersnaam = '$gebruikersnaam' OR email = '$email'";
        $stmt = $pdo->query($sql);
        $stemwijzer = $stmt->FetchAll();

        foreach ($stemwijzer as $stemwijzer) {
            if ($gebruikersnaam === $stemwijzer['gebruikersnaam']) {
                $error = true;
            header('Location: inlog Regri.html?error=gebruikersnaam_bestaat');
            exit();
        }// echo "<script>console.log($stemwijzer);</script>";
        }
        
        
        //echo "<script>console.log($stemwijzer);</script>";
        
        // // Versleutel wachtwoord
        // $hashedWachtwoord = password_hash($wachtwoord, PASSWORD_DEFAULT);

        // // Voeg toe aan database
        // $stmt = $pdo->prepare("INSERT INTO users (geboortedatum, email, gebruikersnaam, wachtwoord, voorwaarden, privacy) VALUES (?, ?, ?, ?, ?, ?)");
        // $stmt->execute([$geboortedatum, $email, $gebruikersnaam, $hashedWachtwoord, $voorwaarden, $privacy]);

        // echo "✅ Account succesvol aangemaakt!";
    }
    ?>

    

<HTML lang="NL">
<!DOCTYPE html>
    <head>
        <title>Stemwijzer</title>
        <link rel="Stylesheet" href="regri.css"/>
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
                        <a class="buttonNav" href="Inlog.php">inlog</a>
                </button>
            </ul>
            </div>
            </nav>
            <article>
                <form method="post" id="regriForm" action="regridatabase.php">
                <div id="GeboorteDatumVak">
                    <div id="GeboorteDatumText">Geboortedatum:</div>
                    <input id="GeboorteDatumInput" name="GeboorteDatumInput" type="date" required>
                </div>
                <div id="EmailVak">
                    <div id="EmailText">E-Mailadres:</div>
                    <input id="EmailInput" name="EmailInput" type="email" required>
                </div>
                <div id="GebruikersnaamVak">
                    <div id="GebruikersnaamText">Gebruikersnaam:</div>
                    <input id="GebruikersnaamInput" name="GebruikersnaamInput" type="text" maxlength="15" required>
                </div>
                <div id="WachtwoordVak">
                    <div id="WachtwoordText">Wachtwoord:</div>
                    <input id="WachtwoordInput" name="WachtwoordInput" type="password" maxlength="20" required>
                </div>
                <div id="HerhaalWachtwoordVak">
                    <div id="HerhaalWachtwoordText">Herhaal Wachtwoord:</div>
                    <input id="HerhaalWachtwoordInput" name="HerhaalWachtwoordInput" type="password" maxlength="20" required>
                </div>
                <div id="algemenevoorwaardenVak">
                    <input id="algemenevoorwaardenInput" type="checkbox">
                    <div id="algemenevoorwaardenText">
                        <a href="algemene voorwaarden.html" target="_blank">Ik ga akkoord met de algemene voorwaarden</a>
                    </div>
                </div>
                <div id="privacybeleidVak">
                    <input id="privacybeleidInput" type="checkbox">
                    <div id="privacybeleidText">
                        <a href="privacy beleid.html" target="_blank">ik ga akkoord met het privacy beleid</a>
                    </div>
                </div><a>
                    <button href="inlog.php" type="submit" id="regristreerKnop">Maak een account</button>
                </a>
            </form>

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

        <!-- <script>
            document.getElementById('regriForm').addEventListener('submit', function(event) {
            event.preventDefault(); 

            const geboortedatum = document.getElementById('GeboorteDatumInput').value.trim();
            const email = document.getElementById('EmailInput').value.trim();
            const gebruikersnaam = document.getElementById('GebruikersnaamInput').value.trim();
            const wachtwoord = document.getElementById('WachtwoordInput').value.trim();
            const herhaalWachtwoord = document.getElementById('HerhaalWachtwoordInput').value.trim();
            const voorwaarden = document.getElementById('algemenevoorwaardenInput').checked;
            const privacy = document.getElementById('privacybeleidInput').checked;

        if (
            geboortedatum === "" ||
            email === "" ||
            gebruikersnaam === "" ||
            wachtwoord === "" ||
            herhaalWachtwoord === ""
            ) {
                alert("Vul alle velden in.");
        return;
            }

        if (wachtwoord !== herhaalWachtwoord) {
            alert("De wachtwoorden komen niet overeen.");
        return;
            }

        if (!voorwaarden || !privacy) {
            alert("Je moet akkoord gaan met de algemene voorwaarden en het privacybeleid.");
        return;
            }

            window.location.href = "Inlog Regri.html";
        });
        </script> -->

    </body>
</html>