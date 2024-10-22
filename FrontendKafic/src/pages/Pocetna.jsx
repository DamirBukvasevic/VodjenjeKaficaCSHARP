import pocetnaSlika from "../assets/slike/img-3.png";

export default function Pocetna() {
    return (
        <div className="backgroundDiv">
            <h1 className="dobrodosli">Dobrodošli u Kafic APP!</h1>
            <img className="pocetnaSlika" src={pocetnaSlika} alt="pocetna"/>
        </div>
    );
}