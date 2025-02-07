Observer.create({
    type: "pointer",
    wheelSpeed: -1,
    onMove: (self) => { // Fixed syntax error
        gsap.to(".saber", {
            duration: .5,
            rotate: gsap.utils.mapRange(0, window.innerWidth, -110, -70, self.x),
            x: gsap.utils.mapRange(0, window.innerWidth, -100, 100, self.x),
            y: gsap.utils.mapRange(0, window.innerHeight, -75, 75, self.y)
        }); // Added missing closing bracket
    },
    tolerance: 10,
    preventDefault: true,
    debounce: true
});

document.addEventListener('click', () => {
    gsap.to('.body', {
        duration: .5,
        '--hue': gsap.utils.random(0, 360, 1),
    }); // Added missing closing bracket
});