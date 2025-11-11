import * as three from "three";
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls.js';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader.js';
import background from '../img/background.jpg'; //Photo by <a href="https://unsplash.com/@von_co?utm_content=creditCopyText&utm_medium=referral&utm_source=unsplash">Ivana Cajina</a> on <a href="https://unsplash.com/photos/milky-way-asuyh-_ZX54?utm_content=creditCopyText&utm_medium=referral&utm_source=unsplash">Unsplash</a>
var height = window.innerHeight;
var width = window.innerWidth;

//declare loaders
const assetLoader = new GLTFLoader();
const textureLoader = new three.TextureLoader();
const cubeLoader = new three.CubeTextureLoader();

const scene = new three.Scene();
scene.background = cubeLoader.load([background,background,background,background,background,background]);

const renderer = new three.WebGL1Renderer();
renderer.shadowMap.enabled = true;
renderer.setSize(width, height);
document.body.appendChild(renderer.domElement);

const camera = new three.PerspectiveCamera(45, width/height, 0.1, 1000);
const orbit = new OrbitControls(camera, renderer.domElement);
camera.position.set(-100,100,100);
orbit.update();

window.addEventListener('resize', () => {
    var width = window.innerWidth;
    var height = window.innerHeight;
    renderer.setSize(width, height);
    camera.aspect = width/height;
    camera.updateProjectionMatrix();
});

//sun lighting help from https://threejs.org/examples/#webgl_lights_pointlights
const sun = new three.PointLight(0xffffff, 10000);
sun.castShadow = true;
sun.shadow.camera.near = 1;
sun.shadow.camera.far = 100000;
const sunGeo = new three.SphereGeometry(10,10,10);
const sunMat = new three.MeshBasicMaterial({color:0xffd400});
const sunSphere = new three.Mesh(sunGeo, sunMat);
sun.add(sunSphere);
scene.add(sun);
const lastZPos = sunSphere.geometry.attributes.position.array.length-1;

//solar system
const mercuryGeo = new three.SphereGeometry(2,10,10);
const mercuryMat = new three.MeshLambertMaterial({color:0xd3d3d3});
const mercury = new three.Mesh(mercuryGeo,mercuryMat);
scene.add(mercury);
mercury.receiveShadow = true;
const mercuryObj = new three.Object3D();
mercuryObj.add(mercury);
scene.add(mercuryObj);
mercury.position.x = sun.position.x + 15;

const venusGeo = new three.SphereGeometry(3, 10, 10);
const venusMat = new three.MeshLambertMaterial({color: 0xfaf2df});
const venus = new three.Mesh(venusGeo, venusMat);
scene.add(venus);
venus.receiveShadow = true;
const venusObj = new three.Object3D();
venusObj.add(venus);
scene.add(venusObj);
venus.position.x = sun.position.x + 25;

const earthGeo = new three.SphereGeometry(5, 10, 10);
const earthMat = new three.MeshLambertMaterial({color: 0xd4f1f9});
const earth = new three.Mesh(earthGeo, earthMat);
scene.add(earth);
earth.receiveShadow = true;
const earthObj = new three.Object3D();
earthObj.add(earth);
scene.add(earthObj);
earth.position.x = sun.position.x + 40;

const marsGeo = new three.SphereGeometry(4, 10, 10);
const marsMat = new three.MeshLambertMaterial({color: 0xf0e7e7});
const mars = new three.Mesh(marsGeo, marsMat);
scene.add(mars);
mars.receiveShadow = true;
const marsObj = new three.Object3D();
marsObj.add(mars);
scene.add(marsObj);
mars.position.x = sun.position.x + 55;

const jupiterGeo = new three.SphereGeometry(9, 18, 18);
const jupiterMat = new three.MeshLambertMaterial({color: 0xbcafb2});
const jupiter = new three.Mesh(jupiterGeo, jupiterMat);
scene.add(jupiter);
jupiter.receiveShadow = true;
const jupiterObj = new three.Object3D();
jupiterObj.add(jupiter);
scene.add(jupiterObj);
jupiter.position.x = sun.position.x + 75;

const saturnGeo = new three.SphereGeometry(8, 16, 16);
const saturnMat = new three.MeshLambertMaterial({color: 0xe2bf7d});
const saturn = new three.Mesh(saturnGeo, saturnMat);
scene.add(saturn);
saturn.receiveShadow = true;
const saturnObj = new three.Object3D();
saturnObj.add(saturn);
const ringGeo = new three.RingGeometry(10, 13, 20);
const ringMat = new three.MeshLambertMaterial({color: 0xd8ae6d, side: three.DoubleSide});
const ringMat2 = new three.MeshLambertMaterial({color: 0xffee1ab, side: three.DoubleSide});
const ring1 = new three.Mesh(ringGeo, ringMat);
const ring2 = new three.Mesh(ringGeo, ringMat2);
const ring3 = new three.Mesh(ringGeo, ringMat);
ring1.receiveShadow = true;
ring2.receiveShadow = true;
ring3.receiveShadow = true;
ring2.scale.set(1.25, 1.25, 1.25);
ring3.scale.set(1.5, 1.5, 1.5);
saturnObj.add(ring1);
saturnObj.add(ring2);
saturnObj.add(ring3);
scene.add(saturnObj);
saturn.position.x = sun.position.x + 100;
ring1.position.set(saturn.position.x, saturn.position.y, saturn.position.z);
ring2.position.set(saturn.position.x, saturn.position.y, saturn.position.z);
ring3.position.set(saturn.position.x, saturn.position.y, saturn.position.z);
ring1.rotateX(Math.PI/2);
ring2.rotateX(Math.PI/2);
ring3.rotateX(Math.PI/2);

const uranusGeo = new three.SphereGeometry(7, 14, 14);
const uranusMat = new three.MeshLambertMaterial({color: 0xace5ee});
const uranus = new three.Mesh(uranusGeo, uranusMat);
scene.add(uranus);
uranus.receiveShadow = true;
const uranusObj = new three.Object3D();
uranusObj.add(uranus);
scene.add(uranusObj);
uranus.position.x = sun.position.x + 120;

const neptuneGeo = new three.SphereGeometry(6, 12, 12);
const neptuneMat = new three.MeshLambertMaterial({color: 0x4b70dd});
const neptune = new three.Mesh(neptuneGeo, neptuneMat);
scene.add(neptune);
neptune.receiveShadow = true;
const neptuneObj = new three.Object3D();
neptuneObj.add(neptune);
scene.add(neptuneObj);
neptune.position.x = sun.position.x + 140;

const plutoGeo = new three.SphereGeometry(2, 10, 10);
const plutoMat = new three.MeshLambertMaterial({color: 0xf7bb7b});
const pluto = new three.Mesh(plutoGeo, plutoMat);
scene.add(pluto);
pluto.receiveShadow = true;
const plutoObj = new three.Object3D();
plutoObj.add(pluto);
scene.add(plutoObj);
pluto.position.x = sun.position.x + 155;

const starURL = new URL('../assets/star.glb', import.meta.url);//"Gold Star" (https://skfb.ly/6woS9) by Oleksandr Pelypenko is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
assetLoader.load(
    starURL.href,
    function(gltf){
        const model = gltf.scene;
        scene.add(model);
        model.position.set(10, 20, 10);
        model.scale.set(10, 10, 10);
    },
    undefined,
    function(error){
        console.error(error);
    }
)

function animate(time){
    sun.rotation.x = time/1000000;
    mercury.rotation.x = time/10000;
    venus.rotation.x = time/100000;
    earth.rotation.x = time/1000;
    mars.rotation.x = time/1000;
    jupiter.rotation.x = time/100;
    saturn.rotation.x = time/100;
    uranus.rotation.x = time/150;
    neptune.rotation.x = time/150;
    pluto.rotation.x = time/10000;

    //help from https://threejs.org/docs/#api/en/core/Object3D.rotation
    venus.rotateOnAxis(new three.Vector3(0,0,0), 177*Math.PI);
    earth.rotateOnAxis(new three.Vector3(0,0,0), 23*Math.PI);
    mars.rotateOnAxis(new three.Vector3(0,0,0), 25*Math.PI);
    saturn.rotateOnAxis(new three.Vector3(0,0,0), 27*Math.PI);
    uranus.rotateOnAxis(new three.Vector3(0,0,0), 98*Math.PI);
    neptune.rotateOnAxis(new three.Vector3(0,0,0), 17*Math.PI);

    mercuryObj.rotation.y = time/450;
    venusObj.rotation.y = time/750;
    earthObj.rotation.y = time/1000;
    marsObj.rotation.y = time/1700;
    jupiterObj.rotation.y = time/4000;
    saturnObj.rotation.y = time/8000;
    uranusObj.rotation.y = time/16000;
    neptuneObj.rotation.y = time/32000;
    plutoObj.rotation.y = time/64000;

    for (let i = 0; i < sunSphere.geometry.attributes.position.array.length; i+=15){
        sunSphere.geometry.attributes.position.array[i] = 3*Math.random();
        sunSphere.geometry.attributes.position.array[lastZPos] = 5*Math.random();
    }
    sunSphere.geometry.attributes.position.needsUpdate = true;

    renderer.render(scene,camera);
}
renderer.setAnimationLoop(animate);