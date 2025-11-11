import { GUI } from "dat.gui";
import * as three from "three";
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls.js'

var height = window.innerHeight;
var width = window.innerWidth;

const renderer = new three.WebGLRenderer();
renderer.setSize(width, height);
renderer.shadowMap.enabled = true;
document.body.appendChild(renderer.domElement);

const scene = new three.Scene();
const cam = new three.PerspectiveCamera(45, width/height, .1, 1000);
const orbit = new OrbitControls(cam, renderer.domElement);
cam.position.set(-10, 30, 30);
orbit.update();

const ambLight = new three.AmbientLight(0x6A0D83);
scene.add(ambLight);
const dirLight = new three.DirectionalLight(0xEEAF61, 1);
dirLight.castShadow = true;
scene.add(dirLight);
dirLight.position.set(-20, 15, 1);

const planeGeo = new three.PlaneGeometry(30,30);
const planeMat = new three.MeshBasicMaterial({color:0xEE5D6C, side:three.DoubleSide});
const plane = new three.Mesh(planeGeo, planeMat);
plane.receiveShadow = true;
scene.add(plane);
plane.rotation.x = -.5 * Math.PI;

const coneGeo = new three.ConeGeometry(5, 20, 32);
const coneMat = new three.MeshLambertMaterial({color: 0xFFCB85, wireframe: true});
const cone = new three.Mesh(coneGeo, coneMat);
cone.castShadow = true;
scene.add(cone);
cone.position.y = 5;
//help from https://stackoverflow.com/questions/29907536/how-can-i-rotate-a-mesh-by-90-degrees-in-threejs
cone.rotation.x = Math.PI;
//help from https://threejs.org/docs/#api/en/core/Object3D.scale
cone.scale.set(.5, .5, .5);

const doDecGeo = new three.DodecahedronGeometry();
const doDecMat = new three.MeshLambertMaterial({color: 0xFFC5D9});
const doDec = new three.Mesh(doDecGeo, doDecMat);
doDec.castShadow = true;
scene.add(doDec);
doDec.scale.set(3.25, 3.25, 3.25);

const gui = new GUI();
const guiOptions = {
    coneSpeed: 10000,
    doDecSpeed: 1.5
}
gui.add(guiOptions, 'coneSpeed', 1000, 10000);
gui.add(guiOptions, 'doDecSpeed', 1.5, 1.6);

var angle = 0;
function animate(time){
    cone.rotation.y = time/guiOptions.coneSpeed;
    
    angle += guiOptions.doDecSpeed;
    doDec.position.y = 12 + Math.abs(Math.sin(angle));
    renderer.render(scene, cam);
}
renderer.setAnimationLoop(animate);